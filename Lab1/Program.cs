using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1
{
	class Program
	{
		private static Phonebook phonebook;

		static void Main(string[] args)
		{
			phonebook = new Phonebook();
			ShowInitialInfoCommand();
			bool shouldExit = false;
			while (true)
			{
				switch (IntInputValidator("Введите команду (Помощь: 9)"))
				{
					case 1:
					{
						NewContactCommand();
						break;
					}
					case 2:
					{
						ShowInfoCommand();
						break;
					}
					case 3:
					{
						AddNewInfoCommand();
						break;
					}
					case 7:
					{
						DeleteProfileCommand();
						break;
					}
					case 8:
					{
						ShowAllContactsCommand();
						break;
					}
					case 4:
					{
						GoToPreviousCommand();
						break;
					}
					case 6:
					{
						GoToNextCommand();
						break;
					}
					case 9:
					{
						ShowInitialInfoCommand();
						break;	
					}
					case 69:
					{
                        Console.WriteLine("Nice");
						break;
					}
					case 0:
					{
						shouldExit = true;
						break;
					}
					default:
					{
                        Console.WriteLine("Неверный номер команды");
						break;
					}
				}

				if (shouldExit)
				{
                    Console.WriteLine("До свидания!");
					break;
				}

			}
		}

        private static void DeleteProfileCommand()
        {
			Console.WriteLine();

			if (!phonebook.IsValidProfileId())
			{
				Console.WriteLine("Нельзя удалить то, чего ещё нет");
				Console.WriteLine();
				return;
			}

			
			Console.WriteLine("Вы уверены, что хотите удалить профиль этого человека?");
			Console.WriteLine(phonebook.GetShortInfo());
			Console.WriteLine();
			Int64 choice = IntInputValidator("Да - 1 | Нет - любое число другое");
			if (choice != 1)
			{
				Console.WriteLine();
				return;
			}

			phonebook.DeleteProfile();
			Console.WriteLine("Профиль удалён");
			Console.WriteLine();
			return;
		}

        private static void ShowInitialInfoCommand()
        {
			Console.WriteLine();
			Console.WriteLine("Добро пожаловать в Записную книжку!");
			Console.WriteLine("Чтобы добавить новый контакт нажмите 1");
			Console.WriteLine("Чтобы отобразить полную информацию о выбранном контакте нажмите 2");
			Console.WriteLine("Чтобы добавить/изменить информацию о выбранном контакте нажмите 3");
			Console.WriteLine("Чтобы удалить выбранный контакт нажмите 7");
			Console.WriteLine("Чтобы вывести все контакты нажмите 8");
			Console.WriteLine("Чтобы перейти на следующую запись нажмите 6");
			Console.WriteLine("Чтобы перейти на предыдущую запись нажмите 4");
			Console.WriteLine("Чтобы вывести это сообщение ещё раз нажмите 9");
			Console.WriteLine("Чтобы выйти нажмите 0");
			Console.WriteLine();
		}

        private static void GoToPreviousCommand()
        {
			Console.WriteLine();
			phonebook.GoToPreviousProfile();
            Console.WriteLine(phonebook.GetShortInfo());
			Console.WriteLine();
		}

		private static void GoToNextCommand()
		{
			phonebook.GoToNextProfile();
			Console.WriteLine(phonebook.GetShortInfo());
			Console.WriteLine();
		}

		private static void ShowAllContactsCommand()
        {
			Console.WriteLine();
			phonebook.ShowAllProfiles();
			Console.WriteLine();
		}

        private static void AddNewInfoCommand()
		{
			Console.WriteLine();
			if (!phonebook.IsValidProfileId())
			{
                Console.WriteLine("Контакт не выбран!");
				return;
			}

			Console.WriteLine("Текущий контакт:");
			phonebook.GetFullInfoAboutProfile();

			Console.WriteLine();
			Console.WriteLine("Чтобы изменить имя нажмите 1");
			Console.WriteLine("Чтобы изменить фамилию нажмите 2");
			Console.WriteLine("Чтобы добавить/изменить отчество нажмите 3");
			Console.WriteLine("Чтобы изменить номер телефона нажмите 4");
			Console.WriteLine("Чтобы изменить страну нажмите 5");
			Console.WriteLine("Чтобы добавить/изменить день рождения нажмите 6");
			Console.WriteLine("Чтобы добавить/изменить организацию нажмите 7");
			Console.WriteLine("Чтобы добавить/изменить должность нажмите 8");
			Console.WriteLine("Чтобы добавить/изменить доп. заметку нажмите 9");
			Console.WriteLine("Чтобы вернуться нажмите 0");


			switch (IntInputValidator("Введите команду"))
			{
				case 1:
					{
						phonebook.EditName(InputValidator("Введите имя:"));
						break;
					}
				case 2:
					{
						phonebook.EditSurname(InputValidator("Введите фамилию:"));
						break;
					}
				case 3:
					{
						phonebook.EditPatronymic(InputValidator("Введите отчество:"));
						break;
					}
				case 4:
					{
						phonebook.EditPhoneNumber(IntInputValidator("Введите номер телефона:"));
						break;
					}
				case 5:
					{
						phonebook.EditCountry(InputValidator("Введите страну:"));
						break;
					}
				case 6:
					{
						phonebook.EditBirthday(InputValidator("Введите информацию о дне рождения:"));
						break;
					}
				case 7:
					{
						phonebook.EditOrganisation(InputValidator("Введите организацию:"));
						break;
					}
				case 8:
					{
						phonebook.EditJob(InputValidator("Введите должность:"));
						break;
					}
				case 9:
					{
						phonebook.EditNotes(InputValidator("Введите заметку (одной строкой):"));
						break;
					}
				case 0:
					{
						Console.WriteLine();
						return;
					}
				default:
					{
                        Console.WriteLine("Неверная команда");
						break;
					}
			}
            Console.WriteLine("Информация обновлена!");
			Console.WriteLine();
		}

        private static void ShowInfoCommand()
        {
			Console.WriteLine();
			phonebook.GetFullInfoAboutProfile();
            Console.WriteLine();
		}

        private static void NewContactCommand()
		{
			Console.WriteLine();
			Console.WriteLine("Введите имя, фамилию, номер телефона и страну контакта");
			String newName = InputValidator("Введите имя:");
			String newSurname = InputValidator("Введите фамилию:");
			Int64 newPhoneNumber = IntInputValidator("Введите номер телефона (только цифры):");
			String newCountry = InputValidator("Введите страну:");
			phonebook.AddNewProfile(newPhoneNumber, newName, newSurname, newCountry);
			Console.WriteLine("Новый контакт успешно добавлен!");
			Console.WriteLine();
		}

		private static String InputValidator(String context)
		{
			String input;
			while (true)
			{
				Console.WriteLine(context);
				input = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(input))
					Console.WriteLine("Неверный ввод. Попробуйте ввести ещё раз");
				else
					break;
			}

			return input;
		}

		private static Int64 IntInputValidator(String context)
		{
			Int64 value;
			while (true)
			{
				Console.WriteLine(context);
				if (!Int64.TryParse(Console.ReadLine(), out value))
					Console.WriteLine("Неверный формат. Попробуйте ввести номер ещё раз");
				else
					break;
			}

			return value;
		}

	}

	public class Phonebook
	{
		private readonly List<Profile> profiles;
		private int correntProfileId;


		public Phonebook()
		{
			profiles = new List<Profile>();
			correntProfileId = -1;
		}

		public void GoToNextProfile()
		{
			if (correntProfileId + 1 >= profiles.Count)
			{
				correntProfileId = 0;
				return;
			}

			correntProfileId++;
		}

		public void GoToPreviousProfile()
		{
			if (correntProfileId - 1 < 0)
			{
				correntProfileId = profiles.Count - 1;
				return;
			}

			correntProfileId--;
		}

		public void GetFullInfoAboutProfile()
		{
			if (!IsValidProfileId())
			{
				Console.WriteLine("Не-не-не так не пойдёт");
				return;
			}

			Console.WriteLine(profiles[correntProfileId]);
		}

		public void ShowAllProfiles()
		{
			foreach (Profile profile in profiles)
			{
                Console.WriteLine(profile.ShowShortInfo() + (profiles.FindIndex(0, value => value == profile) == correntProfileId ? "   <=== (Выбранный контакт)" : ""));
			}
		}

		public String GetShortInfo()
		{
			if (!IsValidProfileId())
			{
				return "Не-не-не так не пойдёт";
			}

			return profiles[correntProfileId].ShowShortInfo();
		}

		public void AddNewProfile(Int64 newPhoneNumber, String newName, String newSurname, String newCountry)
		{
			Profile newProfile = new (newPhoneNumber, newName, newSurname, newCountry);
			profiles.Add(newProfile);
			correntProfileId = profiles.FindIndex(0, value => value == newProfile);
		}

		public void DeleteProfile()
		{
			if (!IsValidProfileId())
			{
				Console.WriteLine("Не-не-не так не пойдёт");
				return;
			}

			profiles.RemoveAt(correntProfileId);
			GoToPreviousProfile();
		}

		public void EditPatronymic(String newPatronymic)
		{
			if (!IsValidProfileId())
			{
				Console.WriteLine("Не-не-не так не пойдёт");
				return;
			}

			profiles[correntProfileId].Patronymic = newPatronymic;
		}

		public void EditName(String newName)
		{
			if (!IsValidProfileId())
			{
				Console.WriteLine("Не-не-не так не пойдёт");
				return;
			}

			profiles[correntProfileId].Name = newName;
		}

		public void EditSurname(String newSurname)
		{
			if (!IsValidProfileId())
			{
				Console.WriteLine("Не-не-не так не пойдёт");
				return;
			}

			profiles[correntProfileId].Surname = newSurname;
		}

		public void EditPhoneNumber(Int64 newPhoneNumber)
		{
			if (!IsValidProfileId())
			{
				Console.WriteLine("Не-не-не так не пойдёт");
				return;
			}

			profiles[correntProfileId].PhoneNumber = newPhoneNumber;
		}

		public void EditCountry(String newCountry)
		{
			if (!IsValidProfileId())
			{
				Console.WriteLine("Не-не-не так не пойдёт");
				return;
			}

			profiles[correntProfileId].Country = newCountry;
		}

		public void EditBirthday(String newBirthday)
		{
			if (!IsValidProfileId())
			{
				Console.WriteLine("Не-не-не так не пойдёт");
				return;
			}

			profiles[correntProfileId].Birthday = newBirthday;
		}

		public void EditOrganisation(String newOrganisation)
		{
			if (!IsValidProfileId())
			{
				Console.WriteLine("Не-не-не так не пойдёт");
				return;
			}

			profiles[correntProfileId].Organisation = newOrganisation;
		}

		public void EditJob(String newJob)
		{
			if (!IsValidProfileId())
			{
				Console.WriteLine("Не-не-не так не пойдёт");
				return;
			}

			profiles[correntProfileId].Job = newJob;
		}

		public void EditNotes(String newNotes)
		{
			if (!IsValidProfileId())
			{
				Console.WriteLine("Не-не-не так не пойдёт");
				return;
			}

			profiles[correntProfileId].Notes = newNotes;
		}

		public bool IsValidProfileId()
		{
			if (correntProfileId >= profiles.Count)
				return false;

			if (correntProfileId < 0)
				return false;

			if (profiles[correntProfileId] == null)
				return false;

			return true;
		}
	}

	public class Profile
	{
		public String Name { get; set; }
		public String Surname { get; set; }
		public String Patronymic { get; set; }
		public Int64 PhoneNumber { get; set; }
		public String Country { get; set; }
		public String Birthday { get; set; }
		public String Organisation { get; set; }
		public String Job { get; set; }
		public String Notes { get; set; }

		public Profile(Int64 newPhoneNumber, String newName, String newSurname, String newCountry)
		{
			Name = newName;
			Surname = newSurname;
			Country = newCountry;
			PhoneNumber = newPhoneNumber;
		}

		public String ShowShortInfo()
		{
			return $"Пользователь: {Name} {Surname} {(Patronymic ?? "")} | Номер телефона: {PhoneNumber}";
		}

		public override string ToString()
		{
			return $"Пользователь: {Name} {Surname} {(Patronymic ?? "")}\n" +
				   $"Номер телефона: {PhoneNumber}\n" +
				   $"Страна: {(Country ?? "Не задана")}\n" +
				   $"День рождения: {(Birthday ?? "Не задан")}\n" +
				   $"Организация: {(Organisation ?? "Не задана")}\n" +
				   $"Должность: {(Job ?? "Не задана")}\n" +
				   $"Дополнительная заметка: {(Notes ?? "Не задана")}\n";
		}

	}


}
