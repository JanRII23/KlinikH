function addReveal(htmlElement, passwordInputId) {
    if (passwordInputId.type === 'password') {
        passwordInputId.type = 'text';
        htmlElement.classList.remove('bi-eye');
        htmlElement.classList.add('bi-eye-slash');
    } else {
        passwordInputId.type = 'password';
        htmlElement.classList.remove('bi-eye-slash');
        htmlElement.classList.add('bi-eye');
    }
}

function hideReveal(passwordInputId) {
    if (passwordInputId.type === 'text') {
        passwordInputId.type = 'password';
        htmlElement = document.querySelector('#revealPassword');
        htmlElement.classList.remove('bi-eye-slash');
        htmlElement.classList.add('bi-eye');
    }
}


if (document.querySelector('#revealPassword') && document.querySelector('#passwordGroup')) {
    const revealElement = document.querySelector('#revealPassword');
    const passwordInputId = document.getElementById('passwordInput');

    revealElement.addEventListener('click', () => {
        addReveal(revealElement, passwordInputId);
    });

    document.querySelector('#passwordGroup').addEventListener('focusout', () => {
        hideReveal(passwordInputId);
    })
}

if (document.querySelector('#revealConfirmPassword')) {
    const revealElement = document.querySelector('#revealConfirmPassword');
    const passwordInputId = document.getElementById('passwordConfirmInput');

    revealElement.addEventListener('click', () => {
        addReveal(revealElement, passwordInputId);
    });

    document.querySelector('#confirmPasswordGroup').addEventListener('focusout', () => {
        hideReveal(passwordInputId);
    })
}


