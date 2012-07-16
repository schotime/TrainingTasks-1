using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks2.ISP
{
    public interface IAnimal : ICanFly, ICanRun
    {
        void See();
        void Eat();
    }

    public interface ICanFly
    {
        void Fly();
    }

    public interface ICanRun
    {
        void Run();
    }
}
