public class FilmEntry
{
    public string filmTitle;
    public string createdBy;
    public int releaseYear;
    public double score;
    public FilmEntry nextEntry;
    public FilmEntry prevEntry;

    public FilmEntry(string filmTitle,string createdBy,int releaseYear,double score)
    {
        this.filmTitle=filmTitle;
        this.createdBy=createdBy;
        this.releaseYear=releaseYear;
        this.score=score;
        this.nextEntry=null;
        this.prevEntry=null;
    }
}
