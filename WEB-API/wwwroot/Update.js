

const user2 = JSON.parse(sessionStorage.getItem("User"));
document.querySelector("#firstName").value = user2.firstName;
document.querySelector("#lastName").value = user2.lastName;
document.querySelector("#userEmail").value = user2.userEmail;
document.querySelector("#password").value = user2.password;

const Update = async () => {

    const userId = user2.id;
    const userUpdate = {
        firstName: document.querySelector("#firstName").value,
        lastName: document.querySelector("#lastName").value,
        userEmail: document.querySelector("#userEmail").value,
        password: document.querySelector("#password").value,
        id: userId
    };
   
    

    try {
        const responsePut = await fetch(`api/Users/${userId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userUpdate)
        });
        if (responsePut.ok) {
            sessionStorage.setItem("User", JSON.stringify(userUpdate));
            alert("The user update");
        }
        else
            throw new Error("The user is not update");
    }
    catch(e) {
        alert(e.message);
    }
}