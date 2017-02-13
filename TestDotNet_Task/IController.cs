﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDotNet_Task
{
    interface IController<T> : IDisposable where T : class 
    {
        IEnumerable<T> GetAll();
        void Create(T category);
        void Update(T entity);
        void Delete(int id);
        T GetById(int id);
    }
}
