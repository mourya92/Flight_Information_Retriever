using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Airport_controller
    {
        public string printData(int line_number)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Sample.txt");

            int counter = 0;
            string output = string.Empty;

            string Op_Carrier = null;
            string stringStart = null;
            string Carrier = null;

            char delimiterChars = ' ';

            string[] words = lines[line_number].Split(delimiterChars);
            
            int i=0;

           
            {
                var text = lines[line_number];
                text= String.Copy(String.Join(" ", text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)));
               
                if(Char.IsNumber(text[0]))
                    text = text.Remove(0,1);
                if (Char.IsNumber(text[0]))
                    text = text.Remove(0, 1);

                if (!(Char.IsWhiteSpace(text[0])))
                {
                    stringStart = text.Substring(0, text.IndexOf(":"));
          
                    Carrier = stringStart;
                    Console.WriteLine(Carrier+ "  Carrier");

                    stringStart = text.Substring(text.IndexOf(":")+1, text.Length-3);              

                     Op_Carrier = stringStart.Substring(0, 2); 
                    Console.WriteLine(Op_Carrier+ "  OperatingCarrier");
                    counter = 2;

                    text = stringStart; 
                }
                else
                {
                    var text1 = String.Copy(String.Join(" ", text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)));
                    stringStart = text1.Substring(0, 2);
                    Carrier = stringStart;
                    Console.WriteLine(Carrier + "  Carrier");

                    Op_Carrier = " ";
                    Console.WriteLine("    OperatingCarrier");
                    counter = 2;

                    text = text1;

                }

                string flightNumber;

                if (Char.IsWhiteSpace(text[2]))
                {
                    text = text.Remove(0,3);
                    flightNumber = text.Substring(0, text.IndexOf(" "));
                    counter = 3;
                    text = text.Remove(0, counter+1);
                }
                else
                {
                    text = text.Remove(0, 2);
                    flightNumber = text.Substring(0, text.IndexOf(" "));
                    counter = 4;
                    text = text.Remove(0, counter+1);

                }

                Console.WriteLine(flightNumber + "  flightNumber");

                counter = 0;

                string[] words1 = text.Split(delimiterChars);
                string sub_class= " "; 

                foreach (string s in words1)
                {
                    if (s.Length == 2)
                    {
                        sub_class = sub_class + s[0];
                        counter++;
                    }
                    else break;
                }

                Console.WriteLine(sub_class + "  Class");
                counter = counter * 2 + (counter - 1);

                text = text.Remove(0,counter+1);

                if((Char.Equals(text[0],'/')))
                    text = text.Remove(0,1);
                string Dep_airport = text.Substring(0, 3);
                Console.WriteLine(Dep_airport + "  Departure Airport");

                text = text.Remove(0, 3);
                int j=0;

                text = text.Remove(0, text.IndexOf("LAX"));

                string Arr_airport = text.Substring(0, 3);

                Console.WriteLine(Arr_airport + "  Arrival Airport");

                text = text.Remove(0, 4);

                words1 = text.Split(delimiterChars);

                foreach (string s in words1)
                    if (s.Length == 4)
                    {
                        text = text.Remove(0, text.IndexOf(s));
                        break;
                    }

                string Departure_time = text.Substring(0, 4);
                Console.WriteLine(Departure_time + "  Departure time");

                text = text.Remove(0, 5);

                string Arrival_time = text.Substring(0, 4);
                Console.WriteLine(Arrival_time + "  Arrival time");
                text = text.Remove(0, 4);

                string time_shift=null;

                if (((int)text[0] == 43) || ((int)text[0]) == 45)
                { time_shift = text.Substring(0, 2); text = text.Remove(0, 2); }

                Console.WriteLine(time_shift + "  ArrivalTimeShift");

                text = text.Remove(0, 1);

                text = text.Remove(0, text.IndexOf("E0") + 3);

                string equipment = text.Substring(0, text.IndexOf(" "));

                Console.WriteLine(equipment + "  Equipment");

                text = text.Remove(0,4);

                char on_time = text[0];

                if ((int)text[1] == 58)
                    on_time = ' ';
                else
                    text = text.Remove(0,2);

                Console.WriteLine(on_time+ "  OnTime");
                string Duration = text.Substring(0, 4);

                Console.WriteLine(Duration+ "  Duration");

                 output = Carrier+ "  Carrier"+ "\n"  + Op_Carrier +" Operation Carrier"+ "\n" + flightNumber + "  flightNumber" + "\n" + Dep_airport + "  Departure Airport" + "\n" + Arr_airport + "  Arrival Airport" + "\n" + Departure_time + "  Departure time" + "\n" + Arrival_time + "  Arrival time" + "\n" + equipment + " Equipment" + "\n" + on_time + "  OnTime" + "\n" + Duration + " Duration";
                Console.WriteLine("jjb:" + text);

               

            }
            return output;
        }
    }
}
