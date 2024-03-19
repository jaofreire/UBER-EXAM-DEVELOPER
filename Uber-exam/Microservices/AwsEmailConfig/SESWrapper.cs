using Amazon;
using Amazon.Runtime;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Microservices.AwsEmailConfig
{
    public class SESWrapper
    {
        private readonly IConfiguration _configuration;

        public SESWrapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IAmazonSimpleEmailService CreateSES()
        {
            var awsCredentials = new BasicAWSCredentials(_configuration.GetValue<string>("AWS:AccessKey"), _configuration.GetValue<string>("AWS:AccessSecretKey"));

            var clientConfig = new AmazonSimpleEmailServiceConfig()
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName("us-east-2")
            };

            return new AmazonSimpleEmailServiceClient(awsCredentials, clientConfig);
        }

        public async Task<SendEmailResponse> SendEmail(SendEmailRequest request)
        {
            var sesClient = CreateSES();
           return await sesClient.SendEmailAsync(request);
        }


        public SendEmailRequest EmailRequest(string emailFrom, List<string> emailTo, string subject, string body)
        {
            var requestEmail = new SendEmailRequest()
            {
                Source = emailFrom,
                Destination = new Destination()
                {
                    ToAddresses = emailTo
                },
                Message = new Message()
                {
                    Subject = new Content()
                    {
                        Charset = "UTF-8",
                        Data = subject
                    },

                    Body = new Body()
                    {
                        Text = new Content()
                        {
                            Charset = "UTF-8",
                            Data = body
                        }
                    }
                }

            };
            requestEmail.Source = emailFrom;
            requestEmail.Destination = new Destination()
            {
                ToAddresses = emailTo
            };

            return requestEmail;
        }
    }
}
