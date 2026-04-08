document.addEventListener('DOMContentLoaded', function () {

    // ── AOS scroll animations
    if (typeof AOS !== 'undefined') {
        AOS.init({
            duration: 800,
            easing: 'ease-in-out',
            once: true
        });
    }

    // ── Bootstrap tooltips
    document.querySelectorAll('[data-bs-toggle="tooltip"]').forEach(function (el) {
        new bootstrap.Tooltip(el);
    });

    // ── Hamburger toggle
    var toggle = document.getElementById('navToggle');
    var menu = document.getElementById('mobileMenu');

    if (toggle && menu) {
        toggle.addEventListener('click', function () {
            var isOpen = menu.classList.toggle('show');
            toggle.classList.toggle('open', isOpen);
            toggle.setAttribute('aria-expanded', String(isOpen));
        });

        menu.querySelectorAll('a').forEach(function (link) {
            link.addEventListener('click', function () {
                menu.classList.remove('show');
                toggle.classList.remove('open');
                toggle.setAttribute('aria-expanded', 'false');
            });
        });

        document.addEventListener('click', function (e) {
            if (!menu.contains(e.target) && !toggle.contains(e.target)) {
                menu.classList.remove('show');
                toggle.classList.remove('open');
                toggle.setAttribute('aria-expanded', 'false');
            }
        });
    }

    // ── Navbar scroll effect
    var navInner = document.querySelector('.zn-nav-inner');
    if (navInner) {
        window.addEventListener('scroll', function () {
            if (window.scrollY > 20) {
                navInner.classList.add('scrolled');
            } else {
                navInner.classList.remove('scrolled');
            }
        }, { passive: true });
    }

});