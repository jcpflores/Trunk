using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using DtrCommon;

namespace DtrController.Tools.GoogleHolidayApi
{
    public class GoogleHolidayApi
    {
        static string[] _scopes = { CalendarService.Scope.CalendarReadonly };

        static ICollection<Holiday> _holidayList = new List<Holiday>();
        
        private static void GetCredentials()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/calendar-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    _scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Holiday Calendar",
            });

            try
            {
                if (_holidayList.Count == 0)
                {
                    var events = service.Events.List("en.philippines#holiday@group.v.calendar.google.com").Execute();

                    foreach (var myEvent in events.Items)
                    {
                        if (DateTime.Parse(myEvent.Start.Date).Year == DateTime.Now.Year)
                        {
                            _holidayList.Add(new Holiday
                            {
                                Id = myEvent.Id,
                                HolidayDate = DateTime.Parse(myEvent.Start.Date),
                                HolidayName = myEvent.Summary
                            });
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public static ICollection<Holiday> GetHolidays()
        {
            GetCredentials();
            return _holidayList;
        }

       
    }
}
