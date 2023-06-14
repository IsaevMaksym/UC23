using ServiceStack.Text;
using UC23.Entities;

namespace UC23
{
    internal static class FileWriter
    {
        public static void SaveCreditsCSV(List<Credits> list)
        {
            if (list.Count == 0)
            {
                return;
            }

            string csvStrings = CsvSerializer.SerializeToCsv(list);
            byte[] csvBytes = System.Text.Encoding.Unicode.GetBytes(csvStrings);
            var fileName = list[0].GetType().ToString() + DateTime.Now.ToString("dd-mm-yyyy") + ".csv";

            SaveToCSV(fileName, csvBytes);
        } 

        public static void SaveTitlesCSV(List<Titles> list)
        {
            if (list.Count == 0)
            {
                return;
            }
            string csvStrings = CsvSerializer.SerializeToCsv(list);
            byte[] csvBytes = System.Text.Encoding.Unicode.GetBytes(csvStrings);
            var fileName = list[0].GetType().ToString() + DateTime.Now.ToString("dd-mm-yyyy") + ".csv";

            SaveToCSV(fileName, csvBytes ); 
        }

        private static void SaveToCSV(string fileName, byte[] csvBytes)
        {
            try
            {
                File.Delete(fileName);
                File.WriteAllBytes(fileName, csvBytes);
            }
            catch (Exception ex)
            {
                throw new Exception("Couldn't save to csv format." + fileName, ex);
            }
        }
    }
}
