namespace _03_AnarchyInTheHospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandSortByName = "1";
            const string CommandSortByAge = "2";
            const string CommandShowPatients = "3";
            const string CommandExit = "4";

            bool isProgramWork = true;
            List<Patient> patients = new List<Patient>()
            {
                new Patient("Олег",20,"гастрит"),
                new Patient("Максим",30,"язва"),
                new Patient("Андрей",40,"гастрит"),
                new Patient("Дмитрий",50,"гастрит"),
                new Patient("Павел",25,"язва"),
                new Patient("Дмитрий",35,"инфаркт"),
                new Patient("Георгий",45,"инфаркт"),
                new Patient("Яков",55,"ковид"),
                new Patient("Тимофей",60,"ковид"),
                new Patient("Андрей",65,"гастрит")
            };

            while (isProgramWork)
            {
                Console.WriteLine($"{CommandSortByName}. Отсортировать всех больных по ФИО.");
                Console.WriteLine($"{CommandSortByAge}. Отсортировать всех больных по возрасту.");
                Console.WriteLine($"{CommandShowPatients}. Вывести больных с определенным заболеванием.");
                Console.WriteLine($"{CommandExit}. Выход.");

                while (isProgramWork)
                {
                    Console.Write("Введите команду: ");

                    switch (Console.ReadLine())
                    {
                        case CommandSortByName:
                            SortByName(patients);
                            break;

                        case CommandSortByAge:
                            SortByAge(patients);
                            break;

                        case CommandShowPatients:
                            ShowPatientsByDisease(patients);
                            break;

                        case CommandExit:
                            isProgramWork = false;
                            break;
                    }
                }
            }
        }

        static void ShowPatientsByDisease(List<Patient> patients)
        {
            string disease;

            Console.Write("Введите название болезни: ");
            disease = Console.ReadLine();

            var filteredPatients = from Patient patient in patients
                                   where patient.Disease == disease
                                   select patient;

            ShowPatients(filteredPatients.ToList());
        }

        static void SortByName(List<Patient> patients)
        {
            var filteredPatients = patients.OrderBy(patient => patient.Name).ToList();

            ShowPatients(filteredPatients);
        }

        static void SortByAge(List<Patient> patients)
        {
            var filteredPatients = patients.OrderBy(patient => patient.Age).ToList();

            ShowPatients(filteredPatients);
        }

        static void ShowPatients(List<Patient> patients)
        {
            foreach (Patient patient in patients)
            {
                Console.WriteLine($"{patient.Name}, {patient.Age} лет, заболевание - {patient.Disease}");
            }
        }
    }

    public class Patient
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Patient(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }
    }
}