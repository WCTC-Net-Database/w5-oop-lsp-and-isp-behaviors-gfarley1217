using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5_assignment_template.Interfaces;

namespace W5_assignment_template.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly IEntity _entity;

        public MoveCommand(IEntity entity)
        {
            _entity = entity;
        }

        public void Execute()
        {
            _entity.Move();
        }
    }

    public class AttackCommand : ICommand
    {
        private readonly IEntity _attacker;
        private readonly IEntity _target; // ChatGPT helped me to understand that readonly means that the value can only be assigned once
        // did not recall prior to looking it up

        public AttackCommand(IEntity attacker, IEntity target)
        {
            _attacker = attacker;
            _target = target;
        }

        public void Execute()
        {
            _attacker.Attack(_target);
        }
    }
}

