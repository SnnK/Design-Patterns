using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            ProfileSettingsCareTaker careTaker = new ProfileSettingsCareTaker();

            ProfileSettings profileSettings = new ProfileSettings
            {
                UserName = "snn",
                Name = "Sinan",
                Email = "sinan@test.com",
                Age = 22
            };

            Console.WriteLine(profileSettings.ToString());

            careTaker.Memento = profileSettings.Backup();

            profileSettings.Name = "Mert";
            profileSettings.UserName = "mrt";

            Console.WriteLine("*****\n" + profileSettings.ToString());

            profileSettings.SetDefaultProfileSettings(careTaker.Memento);

            Console.WriteLine("*****\n" + profileSettings.ToString());

            Console.Read();
        }
    }

    public class ProfileSettings
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        //settings nesnemizin kopyasını oluşturacak.
        public ProfileSettingsMemento Backup()
        {
            ProfileSettingsMemento settingsMemento = new ProfileSettingsMemento
            {
                UserName = UserName,
                Name = Name,
                Email = Email,
                Age = Age
            };

            return settingsMemento;
        }

        //aldığımız kopyadaki verileri profilesettings nesnemize geri atıyoruz.
        public void SetDefaultProfileSettings(ProfileSettingsMemento settingsMemento)
        {
            UserName = settingsMemento.UserName;
            Name = settingsMemento.Name;
            Email = settingsMemento.Email;
            Age = settingsMemento.Age;
        }

        public override string ToString()
        {
            return $"Username: {UserName}\nName: {Name}\nEmail: {Email}\nAge: {Age}";
        }
    }

    public class ProfileSettingsMemento
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }

    //Önceki durumu Memento tipinde tutacak olan sınıf.
    public class ProfileSettingsCareTaker
    {
        public ProfileSettingsMemento Memento { get; set; }
    }
}