
const Register = async () => {

    const userData = {
        firstName: document.querySelector("#firstName").value,
        lastName: document.querySelector("#lastName").value,
        userEmail: document.querySelector("#userEmail").value,
        password: document.querySelector("#password").value
    };
    try {
        const responsePost = await fetch('api/Users',
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(userData)
            });

        if (responsePost.ok)
            alert("user succsesfuly added")
        else
            throw ("error, try again")
    }
    catch {
        alert("error, try again")
    }
}

<<<<<<< HEAD
const Strong = async () => {

    password = document.querySelector("#password").value;
    try {
        const responsePost = await fetch('api/Passwords/Password',
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(password)
            });
        if (!responsePost.ok)
            throw new Error (responsePost.status)
        else
        {
            const score = await responsePost.json();
            document.querySelector("#progress").value = score;
        }
    }
    catch(e) {
        alert(e.message)
    }



}

=======
>>>>>>> ba83b32b1f1f1b348d1fb0ce8488e2f4e457b636
const LogIn = async() => {
    const userData = {
        userLogEmail: document.querySelector("#userLogEmail").value,
        logPassword: document.querySelector("#logPassword").value
    }
        const responsePost = await fetch('/api/Users/Login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userData)
        });
    if (responsePost.ok) {
        const user1 = await responsePost.json();
        sessionStorage.setItem("User", JSON.stringify(user1));
        alert("The user already exists: " + user1.firstName);
        const toUpdate = document.querySelector("#toUpdate");
        toUpdate.style.display = "block";
    }
        else
            alert("The user is not found in the system")
}

