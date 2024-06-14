
namespace MyFirstProject.Shared.Models
{
    public class NYCrashItem
    {
        // Create a new class called NYCrashItem with the following properties:
      
        public string CRASH_DATE { get; set; }
        public string CRASH_TIME { get; set; }
        public string BOROUGH { get; set; }
        public string ZIP_CODE { get; set; }
        public string LATITUDE { get; set; }
        public string LONGITUDE { get; set; }
        public string LOCATION { get; set; }
        public string ON_STREET_NAME { get; set; }
        public string CROSS_STREET_NAME { get; set; }
        public string OFF_STREET_NAME { get; set; }
        public int NUMBER_OF_PERSONS_INJURED { get; set; }
            
        public int NUMBER_OF_PERSONS_KILLED { get; set; }
        public int NUMBER_OF_PEDESTRIANS_INJURED { get; set; }
        public int NUMBER_OF_PEDESTRIANS_KILLED { get; set; }
            
        public int NUMBER_OF_CYCLIST_INJURED { get; set; }
        public int NUMBER_OF_CYCLIST_KILLED { get; set; }
        public int NUMBER_OF_MOTORIST_INJURED { get; set; }
        public int NUMBER_OF_MOTORIST_KILLED { get; set; }
        public string CONTRIBUTING_FACTOR_VEHICLE_1 { get; set; }
        public string CONTRIBUTING_FACTOR_VEHICLE_2 { get; set; }
        public string CONTRIBUTING_FACTOR_VEHICLE_3 { get; set; }
        public string CONTRIBUTING_FACTOR_VEHICLE_4 { get; set; }
        public string CONTRIBUTING_FACTOR_VEHICLE_5 { get; set; }
        public string COLLISION_ID { get; set; }
        public string VEHICLE_TYPE_CODE_1 { get; set; }
        public string VEHICLE_TYPE_CODE_2 { get; set; }
        public string VEHICLE_TYPE_CODE_3 { get; set; }
        public string VEHICLE_TYPE_CODE_4 { get; set; }
        public string VEHICLE_TYPE_CODE_5 { get; set; }
        
    }

   
}


