namespace EmailMicroservice.Models
{
    public class EmailRequestModel
    {
        //Add email properties here
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string TemplateId { get; set; }
        public List<string> Params { get; set; }

    }
}
