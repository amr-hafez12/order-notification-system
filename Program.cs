
namespace task_6__order_notifaction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            Emailservices emailservices = new Emailservices();
            SmsServices smssservices = new SmsServices();
            emailservices.subscribe(orderService);
            smssservices.subscribe(orderService);
            
            orderService.watcher += (string msg) => Console.WriteLine($"Lambda Log:{msg}");
            //lambda expression
 
            orderService.filter = (string order) => order.Length > 5;  //func filter

            string result=Console.ReadLine();
            if (result != null)
            {
                 orderService.placeorder(result);
            }
           

        }
    }
    public delegate void Orderhandler(string  orderplacer);
    public  class OrderService
    {
       public Func<string, bool> filter;
        public event Orderhandler watcher;
        public void placeorder(string order)
        {
            Console.WriteLine($"Order Placed: {order}");
            string formatted= order.Formatted();//Extenssion Method
            Console.WriteLine(formatted);
            
            if(filter!=null&&filter(order))
            {
                watcher?.Invoke(order);  

            }
           
        }
    }
    public class Emailservices
    {
        public void subscribe(OrderService s)
        {

            {
                s.watcher += SendEmail;


            }

        }
        public void SendEmail(string order)//handler   
        {
            Console.WriteLine($"Email sent for order: {order}");
        }
    }
    public class SmsServices
    {
        public void subscribe(OrderService s)
        {

            {
                s.watcher += SendSms;


            }

        }
        public void SendSms(string order)//handler   
        {
            Console.WriteLine($"Sms sent for order: {order}");
        }
    }
    public static class orderExtenssion
    {
        public static string Formatted(this string msg)
        {
            return $"Formatted {msg}";
        }
    }
}
