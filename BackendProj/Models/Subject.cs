namespace BackendProj.Models;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Grade> Grades { get; set; }
    public Teacher Teacher { get; set; }
}