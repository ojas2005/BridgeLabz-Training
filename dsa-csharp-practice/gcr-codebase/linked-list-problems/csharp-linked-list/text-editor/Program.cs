class Program
{
    static void Main()
    {
        RevisionEditor editor=new RevisionEditor(10);

        editor.append("My name is ojas");
        editor.append("My name is ojas,I am from Etawah");
        editor.append("My name is ojas,I am from Etawah,I am doing my code");
        editor.append("My name is ojas,I am from Etawah,I am doing my code on linked list.");
        editor.showCurrent();
        editor.showTimeline();
        editor.goBack();
        editor.goBack();
        editor.showCurrent();
        editor.goForward();
        editor.showCurrent();
        editor.append("code done");
        editor.showTimeline();
    }
}
