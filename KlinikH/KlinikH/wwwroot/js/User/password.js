function addReveal(htmlElement, passwordInputId) {
    let icon = htmlElement.querySelector('i');

    if (passwordInputId.type === 'password') {
        passwordInputId.type = 'text';
        icon.classList.remove('bi-eye');
        icon.classList.add('bi-eye-slash');
    } else {
        passwordInputId.type = 'password';
        icon.classList.remove('bi-eye-slash');
        icon.classList.add('bi-eye');
    }
}

//TODO: need to fix this actually since the html hierarchy is housing the id wrong

if (document.querySelector('#revealPassword')) {
    document.querySelector('#revealPassword').addEventListener('click', function () {
        const passwordInputId = document.getElementById('passwordInput');
        addReveal(this, passwordInputId);
    });
}

if (document.querySelector('#revealConfirmPassword')) {
    document.querySelector('#revealConfirmPassword').addEventListener('click', function () {
        const passwordInputId = document.getElementById('passwordConfirmInput');
        addReveal(this, passwordInputId);
    });

}
