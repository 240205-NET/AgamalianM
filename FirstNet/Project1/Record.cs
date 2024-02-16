using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Project1{
    public class Record{
        // Fields
        private List<Record> records{get;set;} = new List<Record>();
        public string name{get;set;}
        public int daysPlayed{get;set;}
        public int startingBalance{get;set;}
        public int performance{get;set;}
        private XmlSerializer Serializer = new XmlSerializer(typeof(List<Record>));
        private string path = @"./Scores.txt";

        // Constructors
        public Record(string name, int daysPlayed, int startingBalance, int performance){
            this.name = name;
            this.daysPlayed = daysPlayed;
            this.startingBalance = startingBalance;
            this.performance = performance;
        }
        public Record(){}

        // Methods
        public void Save(){
            Console.WriteLine("Saving Record...");
            records.Add(this);
            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, records);
            stringWriter.Close();
            string[] text = {stringWriter.ToString()};
            File.WriteAllLines(path, text);
        }

        public void ViewRecords(){
            Console.WriteLine("Loading Records...");
            Record record = new Record();
            if(!File.Exists(path)){
                Console.WriteLine("File not found...");
            }else{
                using StreamReader reader = new StreamReader(path);
                var oldRecords = (List<Record>) Serializer.Deserialize(reader);
                if(oldRecords is null){
                    Console.WriteLine("No records found...");
                }else{
                    records = oldRecords;
                }
            }
            foreach(Record r in records){
                Console.WriteLine(r);
            }
        }
        public override string ToString(){
            var sb = new StringBuilder();
            sb.AppendLine("Name: " + name);
            sb.AppendLine("\tDays Played: " + daysPlayed);
            sb.AppendLine("\tStarting Balance: $" + startingBalance);
            sb.AppendLine("\tPerformance: " + performance);
            return sb.ToString();
        }
    }
}

// name
// number of days traded
// starting balance
// amount won/lost
// save record
// load record