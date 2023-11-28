window.addEventListener('DOMContentLoaded', getAllContacts);

let objectId;
let contactsTable = document.querySelector('.contactsTable');

let popupUpdateDiv = document.querySelector('.popupUpdateDiv');
let popupUpdateForm = document.querySelector('.popupUpdateForm');
let popupUpdateCloseButton = document.querySelector('.popupUpdateCloseButton');

let popupCreateDiv = document.querySelector('.popupCreateDiv');
let popupCreateForm = document.querySelector('.popupCreateForm');
let popupCreateCloseButton = document.querySelector('.popupCreateCloseButton');

let createButton = document.getElementById('createButton');
let confirmCreatingButton = document.getElementById('confirmCreatingButton');
let updateContactButton = document.getElementById('updateContactButton');
let deleteContactButton = document.getElementById('deleteContactButton');

createButton.addEventListener('click', () => {
    popupCreateDiv.classList.add('active');
    popupCreateForm.classList.add('active');
});

popupUpdateCloseButton.addEventListener('click', () => {
    popupUpdateDiv.classList.remove('active');
    popupUpdateForm.classList.remove('active');
});

popupCreateCloseButton.addEventListener('click', () => {
    popupCreateDiv.classList.remove('active');
    popupCreateForm.classList.remove('active');
});

confirmCreatingButton.addEventListener('click', async (e) => {

    e.preventDefault();
    var name = nameCreateInput.value;
    var mobilePhone = mobilePhoneCreateInput.value;
    var jobTitle = jobTitleCreateInput.value;
    var birthDate = birthDateCreateInput.value;

    if (name && name != ""
        && birthDate && birthDate != "" 
        && /^[A-ZА-Я][a-zа-яё]*$/.test(name))
    {
        try {
            var result = await fetch(`https://localhost:7022/api/contacts/create`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    name: name,
                    mobilePhone: mobilePhone,
                    jobTitle: jobTitle,
                    birthDate: birthDate
                })
            });

            if (result.ok)
            {
                alert("Contact has been created");
                location.reload();
                popupCreateDiv.classList.remove('active');
                popupCreateForm.classList.remove('active');
                nameCreateInput.value = "";
                mobilePhoneCreateInput.value = "";
                jobTitleCreateInput.value = "";
                birthDateCreateInput.value = "";
            }
            else
                alert(result.statusText);
        }
        catch
        {
            alert("Contact has not been created");
        }   
    }
    else
        alert("Name (contains only letters and starts with uppercase letter) and birth date are required.");
});

updateContactButton.addEventListener('click', async (e) => {

    e.preventDefault();

    if (confirm("Do you want to update this contact?") == true) {

        var name = nameUpdateInput.value;
        var mobilePhone = mobilePhoneUpdateInput.value;
        var jobTitle = jobTitleUpdateInput.value;
        var birthDate = birthDateUpdateInput.value;

        if (name && name != ""
            && birthDate && birthDate != ""
            && /^[A-ZА-Я][a-zа-яё]*$/.test(name)
            && objectId
            && objectId > 0) {
            try {
                var result = await fetch(`https://localhost:7022/api/contacts/update`, {
                    method: 'PUT',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({
                        id: objectId,
                        name: name,
                        mobilePhone: mobilePhone,
                        jobTitle: jobTitle,
                        birthDate: birthDate
                    })
                });

                if (result.ok) {
                    alert("Contact has been updated");
                    location.reload();
                    popupUpdateDiv.classList.remove('active');
                    popupUpdateForm.classList.remove('active');
                }
                else
                    alert(result.statusText);
            }
            catch
            {
                alert("Contact has not been updated");
            }
        }
        else
            alert("Name (contains only letters and starts with uppercase letter) and birth date are required, aslo the contact must exist in DB");
    }
    else return
});

deleteContactButton.addEventListener('click', async (e) => {

    e.preventDefault();

    if (confirm("Do you want to delete this contact?") == true)
    {
        if (objectId && objectId > 0)
        {
            try
            {
                var result = await fetch(`https://localhost:7022/api/contacts/${objectId}`, {
                    method: 'DELETE',
                    headers: { 'Content-Type': 'application/json' },
                });

                if (result.ok)
                {
                    alert("Contact has been deleted");
                    location.reload();
                }
                   
                else
                    alert(result.statusText);
            }
            catch
            {
                alert("Contact has not been deleted");
            }
        }
        else
            alert("This contact does not exist");
    }
    else return;
});

async function getAllContacts()
{
    try
    {
        var result = await fetch('https://localhost:7022/api/contacts');

        if (result.ok)
        {
            var contacts = await result.json();

            contacts.forEach((el) => {
                let row = document.createElement('tr');
                row.innerHTML =
                    `<td>${el.name}</td>
                     <td>${el.mobilePhone}</td> 
                     <td>${el.jobTitle}</td>
                     <td>${el.birthDate}</td>`;
                row.id = el.id;
                contactsTable.appendChild(row);
            });

            AddRowsClickLogic();
        }
        else
            alert(result.statusText);
    }
    catch (err)
    {
        alert.error(err);
    }

async function AddRowsClickLogic()
{
    var rows = document.querySelectorAll('tr');
    rows.forEach((r) => {
        r.addEventListener('click', (e) => {
        e.preventDefault();
            document.getElementById('nameUpdateInput').value = r.cells[0].innerHTML;
            document.getElementById('mobilePhoneUpdateInput').value = r.cells[1].innerHTML;
            document.getElementById('jobTitleUpdateInput').value = r.cells[2].innerHTML;
            document.getElementById('birthDateUpdateInput').value = r.cells[3].innerHTML;
            popupUpdateDiv.classList.add('active');
            popupUpdateForm.classList.add('active');
            objectId = r.id;
            });
        });
    }
}