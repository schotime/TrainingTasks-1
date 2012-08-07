using System.Collections.Generic;
using System.Linq;

namespace TrainingTasks3
{
    public class MenuBuilder
    {
        private readonly MenuContext _context;
        private readonly MenuConfig _config;

        public MenuBuilder(MenuContext context, MenuConfig config)
        {
            _context = context;
            _config = config;
        }

        public List<MenuItem> Build()
        {
            var list = new List<MenuItem>(_config.StaticMenuItems);
            list.AddRange(_config.DynamicMenuItemsFunc(_context));
            
            var newlist = new List<MenuItem>();
            foreach (var menuItem in list)
            {
                if (_config.IsVisibleFunc(_context, menuItem))
                {
                    newlist.Add(menuItem);
                }
            }
            return newlist;
        }
    }
}