using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace lab_6_9
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
		private static List<CultureInfo> m_Languages = new List<CultureInfo>();

		public static List<CultureInfo> Languages
		{
			get
			{
				return m_Languages;
			}
		}

		public App()
		{
			// приложение поддерживает след культуры
			m_Languages.Clear();
			m_Languages.Add(new CultureInfo("ru-RU"));
			m_Languages.Add(new CultureInfo("en-US")); 
		}

		//Событие для оповещения всех окон приложения
		public static event EventHandler LanguageChanged;

		public static CultureInfo Language
		{
			get
			{
				return System.Threading.Thread.CurrentThread.CurrentUICulture;
			}
			set
			{
				if (value == null) throw new ArgumentNullException("value");
				if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;

				// Меняем язык приложения
				System.Threading.Thread.CurrentThread.CurrentUICulture = value;

				// Создаём ResourceDictionary для новой культуры
				ResourceDictionary dict = new ResourceDictionary();
				dict.Source = new Uri(string.Format("Language/lang.{0}.xaml", value.Name), UriKind.Relative);

				// Находим старый ResourceDictionary,  
				ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
											  where d.Source != null && d.Source.OriginalString.StartsWith("Language/lang.")
											  select d).First();
				// удаляем его и добавляем новый ResourceDictionary на его место
				if (oldDict != null)
				{
					int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
					Application.Current.Resources.MergedDictionaries.Remove(oldDict);
					Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
				}
				else
				{
					// добавляем новый ResourceDictionary, если нет ни одного
					Application.Current.Resources.MergedDictionaries.Add(dict);
				}

				// Вызываем событие для оповещения всех окон.
				LanguageChanged(Application.Current, new EventArgs());
			}
		}
	}
}
