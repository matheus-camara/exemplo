namespace Domain.Entities.Pros;

public enum EducationLevel : byte
{
    NoEducation = 1,
    HighSchool,
    BachelorsOrHigher
}

public static class EducationLevelExtensions
{
    public static EducationLevel GetEducationLevel(this string that)
    {
        return that switch
        {
            "no_education" => EducationLevel.NoEducation,
            "high_school" => EducationLevel.HighSchool,
            "bachelors_degree_or_high" => EducationLevel.BachelorsOrHigher,
            _ => default!
        };
    }

    public static string GetStringRepresentation(this EducationLevel that)
    {
        return that switch
        {
            EducationLevel.NoEducation => "no_education",
            EducationLevel.HighSchool => "high_school",
            EducationLevel.BachelorsOrHigher => "bachelors_degree_or_high",
            _ => default!
        };
    }
}