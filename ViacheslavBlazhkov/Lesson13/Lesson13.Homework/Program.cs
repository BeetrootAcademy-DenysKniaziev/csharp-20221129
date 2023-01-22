namespace Lesson13.Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product ball = new Product("Soccer Ball", 28.89, 5);
            Product dinotoy = new Product("Dinosaur Toy", 22.8, 4);

            Product[] productsList = new Product[] { ball, dinotoy };

            User firstUser = new User("Oleksiy", "Ivankov", "283-293-8273");
            User secondUser = new User("Nazar", "Galkovich", "382-123-8583");

            firstUser.BuyProducts(secondUser, productsList);

            Product.ShowInfo(ball, dinotoy);

            secondUser.SellProducts(firstUser, productsList);
            User.ShowInfo(firstUser, secondUser);
        }
    }
}