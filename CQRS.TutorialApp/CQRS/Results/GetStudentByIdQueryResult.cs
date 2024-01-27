namespace CQRS.TutorialApp.CQRS.Results
{
    public class GetStudentByIdQueryResult
    {
        // request karşısında response olarak neyi listelemek istiyoruz ? 
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
