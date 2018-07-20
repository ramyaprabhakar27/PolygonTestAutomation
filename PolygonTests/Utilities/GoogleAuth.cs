using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;

namespace PolygonTests.Utilities
{
    public static class GoogleAuth
    {
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Google Sheet API PolygonTestAutomation";
        

        public static IList<IList<Object>> GetData(string sheetRange)
        {
            UserCredential credential;

            using (var stream = new FileStream(@"C:\Users\ramya.prabhakara\Downloads\CSharpPrograms\PolygonTestAutomation\PolygonTests\Utilities\client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-Google Sheet API PolygonTestAutomation.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "ramya.prabhakara@just-eat.com",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            String spreadsheetId = Spreedsheets.SpreadSheetID;
            String range = sheetRange;
            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(spreadsheetId, range);
            ValueRange response = request.Execute();
            return response.Values;
        }

        public static string GetValue(IList<IList<Object>> values)
        {
            if (values != null && values.Count > 0)
            {
                return values[0][0].ToString();
            }
            return null;
        }
    }
}