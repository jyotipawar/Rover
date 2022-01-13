using System;
using Rover;

namespace HelloWorld
{

    class Program
    {
        static string InitialPosition, MovementPlan;
        static int x, y, graph_x, graph_y;
        static char[] Orientation_Array = { 'N', 'E', 'S', 'W' };
        static char Orientation;
        static bool HasRechedBoundary;
       // static bool OutOfborder_graph_y = false, OutOfborder_graph_x = false;


        static void Main(string[] args)
        {

            string Grph_cordinate_str;

            Console.Write("Enter Graph Upper Right Coordinate: ");
            Grph_cordinate_str = Console.ReadLine().ToString();
            string[] Grph_cordinate = Grph_cordinate_str.Split(' ');
            graph_x = int.Parse(Grph_cordinate[0]);
            graph_y = int.Parse(Grph_cordinate[1]);

          //  Console.WriteLine("Right Corner Coordinates are: x = {0} and y = {1} \n", graph_x, graph_y);

            //rover r = new rover();
            //rover r1 = new rover();

            Console.Write("Rover Starting Position: ");
            InitialPosition = Console.ReadLine().ToString();

            string[] Coordinates = InitialPosition.Split(' ');
            x = int.Parse(Coordinates[0]);
            y = int.Parse(Coordinates[1]);
            Orientation = char.Parse(Coordinates[2]);

           // Console.Write("x = {0} y = {1} Orientation = {2} \n", x, y, Orientation);

            while (true)
            {
                HasRechedBoundary = false;
                Console.Write("\nRover 1 Movement Plan: ");
                MovementPlan = Console.ReadLine().ToString();
                char[] MovementPlan_array = MovementPlan.ToCharArray();
                NavigateRover(MovementPlan_array);
                Console.WriteLine("Rover 1 position is: {0} {1} {2} \n", x, y, Orientation);

                //Console.WriteLine("Do you want to continue? y or n: ");
                //string consolkey = Console.ReadLine();
                //if (consolkey == "n")
                //    break;
            }


        }



        static void NavigateRover(char[] MovementPlan_array)
        {
            foreach (char sub_str in MovementPlan_array)
            {
                if (HasRechedBoundary)
                    return;
                switch (sub_str)
                {
                    case 'M':
                        MoveRover();
                        CheckIfOutofBoundary();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'L':
                        TurnLeft();
                        break;
                    default:
                        // Statements to Execute if No Case Matches
                        break;
                }

            }
        }

        static void MoveRover()
        {
            
            switch (Orientation)
            {
                case 'N':
                    y++;
                    break;
                case 'S':
                    y--;
                    break;

                case 'E':
                    x++;
                    break;
                case 'W':
                    x--;
                    break;
                default:
                    break;
            }

        }
        static void CheckIfOutofBoundary()
        {

            if (y > graph_y )
            {
                Console.WriteLine("Rover has reached to the upper boundary and cannot move further");
                y--;
                HasRechedBoundary = true;
            }
            else if (y < 0)
            {
                Console.WriteLine("Rover has reached to the bottom boundary and cannot move further");
                y++;
                HasRechedBoundary = true;
            }

            if (x > graph_x)
            {
                Console.WriteLine("Rover has reached to the right boundary and cannot move further");
                x--;
                HasRechedBoundary = true;

            }
            else if (x < 0)
            {
                Console.WriteLine("Rover has reached to the left boundary and cannot move further");
                x++;
                HasRechedBoundary = true;
            }

        }
        
        static void TurnRight()
        {
            int index = Array.IndexOf(Orientation_Array, Orientation);// increment index
            index++;
            index %= Orientation_Array.Length;             
            Orientation = Orientation_Array[index];
        }

        static void TurnLeft()
        {
            int index = Array.IndexOf(Orientation_Array, Orientation);
            index--; // decrement index
            if (index < 0)
            {
                index = Orientation_Array.Length - 1;
            }
            Orientation = Orientation_Array[index];
        }
    }

}


