using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace HDB01
{

    class Program
    {
        


     
        public class hospital_sites
        {
            public int s_num { get; set; }
            public string site_name { get; set; }
            public string site_address { get; set; }
            public hospital_sites(int s_num, string site_name, string site_address)
            {
                this.s_num = s_num;
                this.site_name = site_name;
                this.site_address = site_address;
            }
        }
        //public class card
        public class Doctors
        {
            public int id_num { get; set; }
            public string fullname { get; set; }
            public string category { get; set; }
            public string experience { get; set; }
            public string DOB { get; set; }
            public string specialization { get; set; }
            public string site { get; set; }
            public int timetable { get; set; }
            public int office_num { get; set; }
            public Doctors(int id_num, string fullname, string category, string experience, string DOB, string specialization, string site, int timetable, int office_num)
            {
                this.id_num = id_num;
                this.fullname = fullname;
                this.category = category;
                this.experience = experience;
                this.DOB = DOB;
                this.specialization = specialization;
                this.site = site;
                this.timetable = timetable;
                this.office_num = office_num;

            }

            internal int Sum(Func<object, object> p) //////
            {
                throw new NotImplementedException();
            }

        }
        class timetable {

            public int dKey { get; set; }
            public string mon { get; set; }
            public string tue { get; set; }
            public string wed { get; set; }
            public string thu { get; set; }
            public string fri { get; set; }
            public string surt { get; set; }
            public string sun { get; set; }
            public timetable(int dKey , string mon, string tue, string wed, string thu, string fri, string surt, string sun)
            {
                this.dKey = dKey;
                this.mon = mon;
                this.tue = tue;
                this.wed = wed;
                this.thu = thu;
                this.fri = fri;
                this.surt = surt;
                this.sun = sun;
            }
        }
        public class patient
        {
            public int id_num { get; set; }
            public string fullname { get; set; }
            public string address { get; set; }
            public string gender { get; set; }
            public double DOB { get; set; }
            public double ins_num { get; set; }
            public string Date_of_visite { get; set; }
            public string complaint { get; set; }
            public string diagnostic { get; set; }
            public string N_Doctor { get; set; }

            public patient(int id_num, string fullname, string address, string gender, double DOB, int ins_num, string Date_of_visite, string complaint, string diagnostic, string N_Doctor)
            {
                this.id_num = id_num;
                this.fullname = fullname;
                this.address = address;
                this.gender = gender;
                this.DOB = DOB;
                this.ins_num = ins_num;
                this.Date_of_visite = Date_of_visite;
                this.complaint = complaint;
                this.diagnostic = diagnostic;
                this.N_Doctor = N_Doctor;
            }


        }

        static int MainMenu()
        {
            Console.Clear();
            Console.Title = "Main menu";

            Console.WriteLine("Select 1 from requests:\n");
            Console.WriteLine(" 1. Information about patients served by the a doctor ");
            Console.WriteLine(" 2. how many nurses at each site");
            Console.WriteLine(" 3. schedue of admission of all doctors of a given specialization");
            Console.WriteLine(" 4. patient information.");
            Console.WriteLine(" 5. name of doctor for a given patient");
            Console.WriteLine(" 6. number of patients served by the doctor.");
            Console.WriteLine(" 7. employing a new medical worker");
            Console.WriteLine(" 8. firing a medical worker");
            Console.WriteLine(" 9. Press Esc to exit.");

            return SelectItem(9);
        }
        static int SelectItem(int items_count)
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape) return Escape;
                try
                {
                    int item = Convert.ToInt32(Convert.ToString((char)key));

                    if (item <= items_count && item > 0)
                        return item;
                    else
                        Console.Write("\n\nThe specified item does not exist!\nPlease re-enter: ");

                }
                catch (FormatException)
                {
                    Console.Write("\n\nYou must specify a numeric value!\nPlease re-enter: ");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.Write("\n\nNumeric value too long!\nPlease re-enter: ");
                    continue;
                }
            }
        }
        static void Main(string[] args)

        {
            {

                
                string str;
                string[] arr = new string[7];

                List<hospital_sites> lst_site = new List<hospital_sites>();    
                List<patient> lst_patient = new List<patient>();     
                List<Doctors> lst_doctors = new List<Doctors>();
                List<timetable> lst_timetable = new List<timetable>();


                string[] arrFiles = { "site.txt", "patient.txt", "workers.txt", "timetable.txt" };

                for (int i = 0; i < arrFiles.Length; i++)
                {
                    try
                    {
                        StreamReader FileIn = new StreamReader("files/" + arrFiles[i], Encoding.Default);
                        while ((str = FileIn.ReadLine()) != null)
                        {
                            arr = str.Split(';');
                            switch (i)
                            {
                                case 0:
                                    lst_site.Add(new hospital_sites(Convert.ToInt16(arr[0]), arr[1], arr[2]));
                                    break;
                                case 1:
                                    lst_patient.Add(new patient(Convert.ToInt32(arr[0]), arr[1], arr[2], arr[3], Convert.ToDouble(arr[4]), Convert.ToInt32(arr[5]), arr[6], arr[7], arr[8], arr[9]));
                                    break;
                                case 2:
                                    lst_doctors.Add(new Doctors(Convert.ToInt32(arr[0]), arr[1], arr[2], arr[3],arr[4], arr[5], arr[6], Convert.ToInt32(arr[7]), Convert.ToInt32(arr[8])));
                                    break;

                                case 3:
                                    lst_timetable.Add(new timetable(Convert.ToInt32(arr[0]), arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7]));
                                    break;
                            }
                        }
                        FileIn.Close();
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        Console.WriteLine("file «" + arrFiles[i] + "» not found!");
                        Console.WriteLine("To exit the program, press any key ...");
                        Console.ReadKey();
                        return;
                    }
                    catch (System.IO.DirectoryNotFoundException)
                    {
                        Console.WriteLine("file «" + arrFiles[i] + "» not found!");
                        Console.WriteLine("To exit the program, press any key...");
                        Console.ReadKey();
                        return;
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("file «" + arrFiles[i] + "» damaged! (Wrong data type) ");
                        Console.WriteLine("To exit the program, press any key ....");
                        Console.ReadKey();
                        return;
                    }
                    catch (System.OverflowException)
                    {
                        Console.WriteLine("file «" + arrFiles[i] + "» damaged! (Numeric value too large) ");
                        Console.WriteLine("To exit the program, press any key ...");
                        Console.ReadKey();
                        return;
                    }
                }
                while (true)
                {
                    switch (MainMenu())
                    {
                        case Escape: return;
                        case 1: query1(lst_patient); break;
                        case 2: query2(lst_doctors); break;
                        case 3: query3(lst_doctors,lst_timetable); break;
                        case 4: query4(lst_patient); break;
                        case 5: query5(lst_patient); break;
                        case 6: query6(lst_patient); break;
                        case 7: Deletelineinfie(); break;
                        case 8: Insetlineinfie(); break;
                    }
                }
            }
        }
        static void query1(List<patient> lst)
        {
            Console.Clear();
            Console.WindowWidth = 140;
            Console.WindowHeight = 36;
            Console.Title = "main menu > patiants served by the doctor";
            Console.WriteLine("\nEnter Doctors name :\n");
            string lukfor;
            lukfor = Console.ReadLine();


            var query = lst.Where(w => w.N_Doctor == lukfor);
            if (query.Count() == 0)
            {
                Console.WriteLine("Sorry, nothing was found on request!");
                Console.Write("\n\n\nTo enter the request menu, press any key ...");
                Console.ReadKey();
            }

            else
            {

                Console.WriteLine("\n {0}.{1,15}\t{2,18}\t{3,20}\t", "fullname", "D.O.B", "GENDER", "ADDRESS");


                foreach (var v in query)
                {
                    Console.WriteLine("\n {0}.{1,15}\t{2,18}\t{3,20}\t", v.fullname, v.DOB, v.gender, v.address);

                }
                Console.Write("\nДля выхода в меню просмотра сведений нажмите любую клавишу...");
                Console.ReadKey();
            }
        }
        static void query2(List<Doctors> lst)
        {
            Console.Clear();
            Console.WindowWidth = 140;
            Console.WindowHeight = 36;
            Console.Title = "main menu > number of nurses at each site";
            var qr2 = lst.GroupBy(a => a.site);
            foreach (var v in qr2)
            {
                int sum = 0;
                Console.WriteLine("\nName of site : {0}", v.Key);
                //Console.WriteLine("\n{0}.{1,15}\t{2,18}\t","fullname","specialization");
                foreach (var wb in v.Where(b => b.category =="nurse"))
                {
                  ++sum;
                  // Console.WriteLine("\n {0}\t{1,-8}", wb.fullname, wb.specialization);
               }
                Console.WriteLine("\n number of nurses {0} ", sum);

            }

            Console.Write("\nДля выхода в меню просмотра сведений нажмите любую клавишу...");
            Console.ReadKey();
        }
        static void query3(List<Doctors> dlst, List<timetable> tlst)
        {
            Console.Clear();
            Console.WindowWidth = 140;
            Console.WindowHeight = 36;
            Console.Title = "main menu > Schaduel for Doctors";
            Console.WriteLine("\nEnter Doctors name speciality :\n");
            string lukfor;
            lukfor = Console.ReadLine();
            var qry3 = dlst.Where(w => w.specialization == lukfor && w.category=="doctor").Join(tlst, a => a.timetable, b => b.dKey,
                           (a, b) => new
                           {
                               a.fullname,
                               a.specialization,
                               a.office_num,
                               b.mon,
                               b.tue,
                               b.wed,
                               b.thu,
                               b.fri,
                               b.surt,
                               b.sun

                           });
          
            if (qry3.Count() == 0)
            {
                Console.WriteLine("Sorry, nothing was found on request!");
                Console.Write("\n\n\nTo enter the request menu, press any key ...");
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine("the scaduel is set as follows");

                Console.WriteLine("\n {0,-10}\t{1,25}\t{2,-8}\t{3,-10}\t{4,-10}\t{5,-10}\t{6,-10}\t{7,-10}\t{8,-10}\t", "ROOM NUMBER", "FULLNAME", " MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SURTDAY", "SUNDAY");
                int num = 1;
                foreach (var arg in qry3)
                {
                    Console.WriteLine("\n {0,-10}\t{1,25}\t{2,-8}\t{3,-10}\t{4,-10}\t{5,-10}\t{6,-10}\t{7,-10}\t{8,-10}\t", arg.office_num, arg.fullname,  arg.mon, arg.tue, arg.wed, arg.thu, arg.fri, arg.surt, arg.sun);
             
                }

                Console.Write("\n\n\nTo enter the main menu, press any key ...");
                Console.ReadKey();
            }
        }
        static void query4(List<patient> lst)
        {
            Console.Clear();
            Console.WindowWidth = 140;
            Console.WindowHeight = 36;
            Console.Title = "main menu > patiant information";
            Console.WriteLine("\nEnter patient's name :\n");
            string lukfor;
            lukfor = Console.ReadLine();





            Console.WriteLine("\n {0,-15}\t{1,18}\t{2,-20}\t", "address", "date of visit", "diagnostic");

            var query = lst.Where(w => w.fullname == lukfor);
            foreach (var v in query)
            {
                Console.WriteLine("\n {0,-15}\t{1,18}\t{2,-20}\t", v.address, v.Date_of_visite, v.diagnostic);

            }
            Console.Write("\nДля выхода в меню просмотра сведений нажмите любую клавишу...");
            Console.ReadKey();
        }
        static void query5(List<patient> lst)
        {
            Console.Clear();
            Console.WindowWidth = 140;
            Console.WindowHeight = 36;
            Console.Title = "main menu > Doctor patiant information";
            Console.WriteLine("\nEnter patient's name :\n");
            string lukfor;
            lukfor = Console.ReadLine();



            var firstname = "";
            var lastname = "";

           // Console.WriteLine("\n {0}. {1,-15}\t{2,18}\t{3,-20}\t{3,-25}", "address", "date of visit", "diagnostic");

            var query = lst.Where(w => w.fullname == lukfor);
            if (query.Count() == 0)
            {
                Console.WriteLine("the patients name does not exist in the system");
            }
            else
            foreach (var v in query)
            {
                    var split = v.N_Doctor.Split(new char[] { ' ' },2);
                    if (split.Length == 1)
                    {
                        firstname = " ";
                        lastname = split[1];
                    }
                    else 
                    {
                        firstname = split[1];
                        lastname = split[0];
                        var name = GetInitials(firstname);
                        Console.WriteLine("\n Doctor : {0} , {1}", lastname, name);
                    }
                  
          
            }
            Console.Write("\nДля выхода в меню просмотра сведений нажмите любую клавишу...");
            Console.ReadKey();
        }

        public static string GetInitials(string name)
        {
            //first remove all: punctuation, separator chars, control chars, and numbers (unicode style regexes)
            string initials = Regex.Replace(name, @"[\p{P}\p{S}\p{C}\p{N}]+", "");

            // Replacing all possible whitespace/separator characters (unicode style), with a single, regular ascii space.
            initials = Regex.Replace(initials, @"\p{Z}+", " ");

            // Remove all Sr, Jr, I, II, III, IV, V, VI, VII, VIII, IX at the end of names
            initials = Regex.Replace(initials.Trim(), @"\s+(?:[JS]R|I{1,3}|I[VX]|VI{0,3})$", "", RegexOptions.IgnoreCase);

            // Extract up to 2 initials from the remaining cleaned name.
            initials = Regex.Replace(initials, @"^(\p{L})[^\s]*(?:\s+(?:\p{L}+\s+(?=\p{L}))?(?:(\p{L})\p{L}*)?)?$", "$1$2").Trim();

            if (initials.Length > 2)
            {
                // Worst case scenario, everything failed, just grab the first two letters of what we have left.
                initials = initials.Substring(0, 2);
            }

            return initials.ToUpperInvariant();
        }
        static void query6(List<patient> lst)
        {
            Console.Clear();
            Console.WindowWidth = 140;
            Console.WindowHeight = 36;
            Console.Title = "main menu > patiant information";
            Console.WriteLine("\n the number of patients each doctor has treated \n");

            var query = lst.GroupBy(w => w.N_Doctor).Select(w=>new
            {
                Str = w.Key,
                Count =w.Count()
            });
            Console.WriteLine("\n{0,-15}\t {1,30}\t", "Name of Doctor" , "Number ");
            foreach (var v in query)
            {
                Console.WriteLine("\n{0,-15}\t{1,30}\t ", v.Str,v.Count);
            }
            Console.Write("\nДля выхода в меню просмотра сведений нажмите любую клавишу...");
            Console.ReadKey();
        }
        public static void Insetlineinfie()
        {
            Console.Clear();
            Console.WindowWidth = 140;
            Console.WindowHeight = 36;
            var FilePath = @"workers.txt";
            StreamWriter emoply = new StreamWriter(FilePath, true);
            Console.Write("\nenter the doctors details as  id_num;fullname;category;experience; DOB;specialization;site;timetable; office_num \n");
            string s = Console.ReadLine();
            emoply.WriteLine(s);
            Console.Write("New employee added.");

            Console.Write("\nДля выхода в меню просмотра сведений нажмите любую клавишу...");
            Console.ReadKey();

        }
        const int Escape = 0;
        public static void Deletelineinfie()
        {
            Console.Clear();
            Console.WindowWidth = 140;
            Console.WindowHeight = 36;
            var FilePath = @"workers.txt";
            string[] lines = File.ReadAllLines(FilePath);
            Console.Write("\nenter the full name of the employee");
            string s = Console.ReadLine();
            File.WriteAllText(FilePath, String.Empty);
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach(string a in lines)
                {
                    if (!a.Contains(s))
                    {
                        writer.WriteLine(a);
                    }
                }
            }
            Console.Write("New employee added.");

            Console.Write("\nДля выхода в меню просмотра сведений нажмите любую клавишу...");
            Console.ReadKey();

        }

    }  
}
