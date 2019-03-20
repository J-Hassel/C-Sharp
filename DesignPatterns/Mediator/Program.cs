using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Chatroom chatroom = new Chatroom();

            Participant Eddie = new Actor("Eddie");
            Participant Jennifer = new Actor("Jennifer");
            Participant Bruce = new Actor("Bruce");
            Participant Tom = new Actor("Tom");
            Participant Tony = new NonActor("Tony");

            chatroom.Register(Eddie);
            chatroom.Register(Jennifer);
            chatroom.Register(Bruce);
            chatroom.Register(Tom);
            chatroom.Register(Tony);

            Tony.Send("Tom", "Hey Tom! I got a mission for you.");
            Jennifer.Send("Bruce", "Teach me to act and I'll teach you to dance.");
            Bruce.Send("Eddie", "How come you don't do standup anymore?");
            Jennifer.Send("Tom", "Do you like math?");
            Tom.Send("Tony", "Teach me to sing.");
        }
    }

    abstract class AbstractChatroom
    {
        public abstract void Register(Participant participant);
        public abstract void Send(string from, string to, string message);
    }

    class Chatroom : AbstractChatroom
    {
        private Dictionary<string, Participant> _participants = new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if(!_participants.ContainsValue(participant))
            {
                _participants[participant.Name] = participant;
            }

            participant.Chatroom = this;
        }

        public override void Send(string from, string to, string message)
        {
            Participant participant = _participants[to];

            if (participant != null)
            {
                participant.Recieve(from, message);
            }
        }
    }

    class Participant
    {
        private Chatroom _chatroom;
        private string _name;

        public Participant(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public Chatroom Chatroom
        {
            get { return _chatroom; }
            set { _chatroom = value; }
        }

        public void Send(string to, string message)
        {
            _chatroom.Send(_name, to, message);
        }

        public virtual void Recieve(string from, string message)
        {
            Console.WriteLine($"{from} to {Name}: '{message}'");
        }
    }

    class Actor : Participant
    {
        public Actor(string name) : base(name)
        {
        }

        public override void Recieve(string from, string message)
        {
            Console.Write("To an Actor: ");
            base.Recieve(from, message); ;
        }
    }

    class NonActor : Participant
    {
        public NonActor(string name) : base(name)
        {
        }

        public override void Recieve(string from, string message)
        {
            Console.Write("To a Non-Actor: ");
            base.Recieve(from, message); ;
        }
    }
}
