  namespace FinalProject;
  public class ApartmentManager
    {
        private static List<Apartment> apartments = new List<Apartment>();


        public static void AddApartment(Apartment apartment)
        {
            apartments.Add(apartment);
            
        }
        
    

       public static Apartment GetApartmentByNumber(string apartmentNumber)
        {
            // Find the apartment by its number
            return apartments.Find(apartment => apartment.ApartmentNumber == apartmentNumber);
    }
    }
