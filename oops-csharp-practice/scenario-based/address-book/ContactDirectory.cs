internal class ContactDirectory
{
    private Contact[] contacts = new Contact[50];
    private int count = 0;
    public void InsertContact(Contact contact)
    {
        if (count < contacts.Length)
        {
            contacts[count++] = contact;
        }
    }
    public Contact[] GetContacts()
    {
        return contacts;
    }
    public int GetCount()
    {
        return count;
    }
}

