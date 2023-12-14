  namespace FinalProject;
  public class ApartmentManager
    {
    public static List<Apartment> Apartments { get; set; } = new List<Apartment>();

    public static void AddApartment(Apartment apartment)
        {
            Apartments.Add(apartment);
            
        }
        
    

       public static Apartment GetApartmentByNumber(string apartmentNumber)
        {
            // Find the apartment by its number
            return Apartments.Find(apartment => apartment.ApartmentNumber == apartmentNumber);
    }
    }
