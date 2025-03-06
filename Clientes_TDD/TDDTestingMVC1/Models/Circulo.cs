namespace TDDTestingMVC1.Models
{
    public class Circulo
    {
        //Const
        public const double PI = 3.1415926535897931;
        public double radius { get; set; }
        public double radiusSquared { get; set; }
        

        public double calculateRadiusSquared()
        {
            return radius * radius; 
        }

        public double calculateCircleArea(double radiusSquared)
        {
            return PI * radiusSquared;
        }
    }
}
