Razor : mélange de C# et html qui peut être utilisé avec ASP.NET pour afficher des données.
(si l'on veut écrire un @ en dur, il faudra le doubler : @@chose non à chercher dans les données)
(-> pas besoin pour mail@domaine.com, il voit que c'est un mail)
(-> sinon, parenthèses : <td>Le nom est : @(resto.Nom).Voilà !</td> )

Exemple :

<table>
    <tr>
        <th>Nom</th>
        <th>Téléphone</th>
    </tr>
    @foreach (var resto in Model)
    {
        <tr>
            <td>@resto.Nom</td>
            <td>@resto.Telephone</td>
        </tr>
    }
</table>

------------------------------------------

Ou encore :

@{
    ViewBag.Title = "Trouve";
}

<div>
    <h2>Le Lapin @ViewData["Nom"] a été trouvé !</h2>
</div>


------------------------------------------


