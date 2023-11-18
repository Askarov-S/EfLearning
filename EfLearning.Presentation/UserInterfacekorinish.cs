using EfLearning.Service.DTOs.UserDto;
using EfLearning.Service.Exceptions;
using EfLearning.Service.Interfaces.UserInterfaces;
using EfLearning.Service.Services.UserServices;

namespace EfLearning.Presentation;

public class UserInterfacekorinish
{
    private readonly IUserService userService;
    public void UI()
    {
        bool check = true;
        while (check)
        {
            Console.WriteLine("1 -> Create");
            Console.WriteLine("2 -> Update");
            Console.WriteLine("3 -> GetById");
            Console.WriteLine("4 -> GetAll");
            Console.WriteLine("5 -> Delete");
            Console.WriteLine("6 -> Move back");

            int num = int.Parse(Console.ReadLine());
            Console.Clear();
            var user = new UserForCreationDto();
            try
            {
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Enter the UserName");
                        user.UserName = Console.ReadLine();
                        Console.WriteLine("Enter the Email");
                        user.Email = Console.ReadLine();
                        Console.WriteLine("Enter the Password");
                        user.Password = Console.ReadLine();

                        var result = this.userService.CreateAsync(user);
                        Console.WriteLine($"{result.Id}|{result.Result.UserName}|{result.Result.Password}|");
                        break;
                    case 2:
                        var person = new UserForUpdateDto();
                        Console.WriteLine("Enter the Id");
                        person.Id = long.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the UserName");
                        person.UserName = Console.ReadLine();

                        var result1 = this.userService.UpdateAsync(person);
                        Console.WriteLine($"{result1.Id}|{result1.Result.UserName}");
                        break;
                    case 3:
                        Console.WriteLine("Enter the Id");
                        var id = long.Parse(Console.ReadLine());
                        var result2 = this.userService.GetAsync(id);
                        Console.WriteLine($"{result2.Id}|{result2.Result.UserName}|{result2.Result.Email}|");
                        break;
                    case 4:
                        var users = this.userService.GetAllAsync();
                        foreach (var human in users)
                        {
                            Console.WriteLine($"{human.Id}|{human.UserName}|{human.Email}|");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter the Id");
                        var Id = long.Parse(Console.ReadLine());
                        this.userService.DeleteAsync(Id);
                        Console.WriteLine("Successfully deleted");
                        break;
                    case 6:
                        check = false;
                        break;
                }
            }
            catch (CustomException ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
        }

    }
}
