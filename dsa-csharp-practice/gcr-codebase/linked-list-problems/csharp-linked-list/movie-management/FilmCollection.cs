public class FilmCollection
{
    private FilmEntry begin;

    public FilmCollection()
    {
        begin=null;
    }

    public void insertAtBegin(string filmTitle,string createdBy,int releaseYear,double score)
    {
        FilmEntry entry=new FilmEntry(filmTitle,createdBy,releaseYear,score);
        if(begin==null)
        {
            begin=entry;
            Console.WriteLine("film added");
            return;
        }
        entry.nextEntry=begin;
        begin.prevEntry=entry;
        begin=entry;
        Console.WriteLine("film added at begin");
    }

    public void insertAtEnd(string filmTitle,string createdBy,int releaseYear,double score)
    {
        FilmEntry entry=new FilmEntry(filmTitle,createdBy,releaseYear,score);
        if(begin==null)
        {
            begin=entry;
            Console.WriteLine("film added");
            return;
        }
        FilmEntry pointer=begin;
        while(pointer.nextEntry!=null)
            pointer=pointer.nextEntry;
        pointer.nextEntry=entry;
        entry.prevEntry=pointer;
        Console.WriteLine("film added at end");
    }

    public void insertAtIndex(string filmTitle,string createdBy,int releaseYear,double score,int index)
    {
        if(index==1)
        {
            insertAtBegin(filmTitle,createdBy,releaseYear,score);
            return;
        }
        FilmEntry entry=new FilmEntry(filmTitle,createdBy,releaseYear,score);
        FilmEntry pointer=begin;
        int counter=1;
        while(pointer!=null&&counter<index-1)
        {
            pointer=pointer.nextEntry;
            counter++;
        }
        if(pointer==null)
        {
            Console.WriteLine("invalid index");
            return;
        }
        entry.nextEntry=pointer.nextEntry;
        entry.prevEntry=pointer;
        if(pointer.nextEntry!=null)
            pointer.nextEntry.prevEntry=entry;
        pointer.nextEntry=entry;
        Console.WriteLine("film added at index "+index);
    }

    public void deleteByName(string filmTitle)
    {
        if(begin==null)
        {
            Console.WriteLine("list is empty");
            return;
        }
        if(begin.filmTitle==filmTitle)
        {
            begin=begin.nextEntry;
            if(begin!=null)
                begin.prevEntry=null;
            Console.WriteLine("film removed");
            return;
        }
        FilmEntry pointer=begin;
        while(pointer!=null)
        {
            if(pointer.filmTitle==filmTitle)
            {
                if(pointer.prevEntry!=null)
                    pointer.prevEntry.nextEntry=pointer.nextEntry;
                if(pointer.nextEntry!=null)
                    pointer.nextEntry.prevEntry=pointer.prevEntry;
                Console.WriteLine("film removed");
                return;
            }
            pointer=pointer.nextEntry;
        }
        Console.WriteLine("title not found");
    }

    public void findByCreator(string createdBy)
    {
        FilmEntry pointer=begin;
        bool exists=false;
        while(pointer!=null)
        {
            if(pointer.createdBy==createdBy)
            {
                Console.WriteLine("title: "+pointer.filmTitle+" | creator: "+pointer.createdBy+" | year: "+pointer.releaseYear+" | score: "+pointer.score);
                exists=true;
            }
            pointer=pointer.nextEntry;
        }
        if(!exists)
            Console.WriteLine("no films by this creator");
    }

    public void findByScore(double score)
    {
        FilmEntry pointer=begin;
        bool exists=false;
        while(pointer!=null)
        {
            if(pointer.score>=score-0.1&&pointer.score<=score+0.1)
            {
                Console.WriteLine("title: "+pointer.filmTitle+" | score: "+pointer.score);
                exists=true;
            }
            pointer=pointer.nextEntry;
        }
        if(!exists)
            Console.WriteLine("no films with this score");
    }

    public void modifyScore(string filmTitle,double newScore)
    {
        FilmEntry pointer=begin;
        while(pointer!=null)
        {
            if(pointer.filmTitle==filmTitle)
            {
                pointer.score=newScore;
                Console.WriteLine("score updated to "+newScore);
                return;
            }
            pointer=pointer.nextEntry;
        }
        Console.WriteLine("title not found");
    }

    public void displayInOrder()
    {
        if(begin==null)
        {
            Console.WriteLine("list is empty");
            return;
        }
        FilmEntry pointer=begin;
        Console.WriteLine("\nfilms in order");
        while(pointer!=null)
        {
            Console.WriteLine(pointer.filmTitle+" | "+pointer.createdBy+" | "+pointer.releaseYear+" | "+pointer.score);
            pointer=pointer.nextEntry;
        }
        Console.WriteLine();
    }

    public void displayInReverse()
    {
        if(begin==null)
        {
            Console.WriteLine("list is empty");
            return;
        }
        FilmEntry pointer=begin;
        while(pointer.nextEntry!=null)
            pointer=pointer.nextEntry;
        Console.WriteLine("\nfilms in reverse");
        while(pointer!=null)
        {
            Console.WriteLine(pointer.filmTitle+" | "+pointer.createdBy+" | "+pointer.releaseYear+" | "+pointer.score);
            pointer=pointer.prevEntry;
        }
        Console.WriteLine();
    }
}
