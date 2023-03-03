//using Calendar.DAL.Repositorys.Interface;
//using Calendar.Contracts.Models;
//using System.Collections.Generic;
//using System.Linq;
//using System.IO;
//using System.Xml.Serialization;

//namespace Calendar.DAL.Repositorys
//{
//    internal class XMLMeetingsRepository : IRepository<Meeting>
//    {      
//        private const string FileName = "Meetings.xml";

//        public void Add(Meeting meeting) 
//        {
//            var meetings = GetAll();
//            meetings = meetings.Append(meeting);

//            var serializer = new XmlSerializer(typeof(Meeting));
//            using (var fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write))
//            {
//               serializer.Serialize(fs, meetings);
//            }
            
//        }
//        public IEnumerable<Meeting> GetAll() 
//        {
//            if (!File.Exists(FileName))
//                return Enumerable.Empty<Meeting>();
//            var serializer = new XmlSerializer(typeof(Meeting));
//            IEnumerable<Meeting> meetings;
//            using (var fs = new FileStream(FileName, FileMode.Open, FileAccess.Read))
//            {
//                meetings = serializer.Deserialize(fs) as IEnumerable<Meeting> ?? Enumerable.Empty<Meeting>();
//            }
//            return meetings;
//        }
//    }
//}
