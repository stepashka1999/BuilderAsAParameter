using System;

namespace BuilderAsAParameter
{
    public class EmailService
    {
        public class EmailBuilder
        {
            private Email _email;
            
            internal EmailBuilder(Email email)
            {
                _email = email;
            }

            public EmailBuilder From(string from)
            {
                _email.From = from;
                return this;
            }

            public EmailBuilder To(string to)
            {
                _email.To = to;
                return this;
            }

            public EmailBuilder WithHeader(string header)
            {
                _email.Header = header;
                return this;
            }

            public EmailBuilder WithMessage(string message)
            {
                _email.Message = message;
                return this;
            }
        }

        internal class Email
        {
            public string From, To, Header, Message;

            public override string ToString()
            {
                return $"From: {From}\nTo: {To}\nHeader: {Header}\n{Message}";
            }
        }

        private void SendMessageInternal(Email email)
        {
            //Sending...
            Console.WriteLine(email);
        }

        public void SendEmail(Action<EmailBuilder> builder)
        {
            var email = new Email();
            builder(new EmailBuilder(email));
            SendMessageInternal(email);
        }
    }

    internal class Program
    {        
        static void Main(string[] args)
        {
            var emailService = new EmailService();
            emailService.SendEmail(
                email =>
                    email.From("shrek@gmail.com")
                    .To("cat1337@gmail.com")
                    .WithHeader("Where r u, asshole?")
                    .WithMessage("Wtf, cat? Where r u? U must be there in 12:00. Now 13:05")
                    );
        }
    }
}
