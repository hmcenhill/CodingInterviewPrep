using System.Linq;

namespace CodingInterviewPrep.ConferenceRoom
{
    public class ConferenceRoomProblem
    {
        private ConferenceRoomManager manager;

        public ConferenceRoomProblem(int numberOfRooms)
        {
            manager = new ConferenceRoomManager(numberOfRooms);
        }
    }

    public class ConferenceRoomManager
    {
        private ConferenceRoom[] Rooms;

        public ConferenceRoomManager(int numberOfRooms)
        {
            Rooms = new ConferenceRoom[numberOfRooms];
            for (var i = 0; i < Rooms.Length; i++)
            {
                Rooms[i] = new ConferenceRoom(i.ToString(), i);
            }
        }

        public ConferenceRoom BookNextRoom(int timeToBook)
        {
            var bookedRoom = Rooms.First();
            bookedRoom.BookUntil(bookedRoom.BookedUntilTime + timeToBook);
            SinkTopRoom();
            return bookedRoom;
        }

        private void SinkTopRoom()
        {
            var index = 0;
            var sinking = true;
            while (sinking)
            {
                if (GetLeft(index) < Rooms.Length)
                {
                    var roomToSwap = GetLeft(index);
                    if (GetRight(index) < Rooms.Length && Rooms[GetRight(index)].AvailableBefore(Rooms[GetLeft(index)]))
                    {
                        roomToSwap = GetRight(index);
                    }
                    if (Rooms[roomToSwap].AvailableBefore(Rooms[index]))
                    {
                        SwapRooms(roomToSwap, index);
                        index = roomToSwap;
                    }
                    else
                    {
                        sinking = false;
                    }
                }
                else
                {
                    sinking = false;
                }
            }
        }

        private void SwapRooms(int x, int y)
        {
            var temp = Rooms[x];
            Rooms[x] = Rooms[y];
            Rooms[y] = temp;
        }

        private int GetLeft(int roomIndex) => roomIndex * 2 + 1;
        private int GetRight(int roomIndex) => roomIndex * 2 + 2;
    }

    public class ConferenceRoom
    {
        public string Name;
        public int Sequence;
        public int BookedUntilTime;

        public ConferenceRoom(string name, int seq)
        {
            Name = name;
            Sequence = seq;
            BookedUntilTime = 0;
        }

        public void BookUntil(int time) => BookedUntilTime = time;

        public bool AvailableBefore(ConferenceRoom otherRoom) => this.BookedUntilTime < otherRoom.BookedUntilTime ||
            (this.BookedUntilTime == otherRoom.BookedUntilTime && this.Sequence < otherRoom.Sequence);
    }
}
