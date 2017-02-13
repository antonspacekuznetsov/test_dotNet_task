using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDotNet_Task
{
    class Procces
    {
        ISmtpSender _sender;
        public Procces()
        {
            _sender = new MailSender();
        }

        public void AddCategory(string categoryTitle)
        {
            try
            {
                using (IController<Category> sql = new Controller<Category>())
                {
                    bool priznak = false;
                    foreach (Category cat in sql.GetAll())
                    {
                        if (cat.Title == categoryTitle)
                        {
                            priznak = true;
                            break;
                        }
                    }

                    if (!priznak)
                    {
                        sql.Create(new Category { Enabled=1, Title =categoryTitle});
                        _sender.SendMail("Новая категория "+ categoryTitle);
                    }

                }
            }
            catch (Exception ex)
            {
               Console.WriteLine("Ошибка" + ex.Message);
            }

        }

        public void AddPost(string PostTitle, int userId, int CategoryId, string body)
        {

            try
            {
                using (IController<Post> sql = new Controller<Post>())
                {

                    sql.Create(new Post { Body = body, UserId = userId, Title = PostTitle});
                    _sender.SendMail("Новый пост " + PostTitle);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка" + ex.Message);
            }
        }

        public void AddToPostCategory(int postId, int categoryId)
        {
            try
            {
                using (IController<Post_to_Category> sql = new Controller<Post_to_Category>())
                {
                    
                    sql.Create(new Post_to_Category { CategoryId = categoryId, PostId = postId});
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка" + ex.Message);
            }
        }


    }

    
}
