// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", () => {
  const toggle = document.getElementById("navToggle");
  const overlay = document.getElementById("navOverlay");
  const NAV_OPEN_CLASS = "open";
  console.log(toggle.getAttribute("aria-expanded"));
  function openNav() {
    const navItems = document.querySelectorAll(".overlay-nav li a");

    navItems.forEach((item) => {
      // Prevent duplication if already added
      if (!item.querySelector(".bi.bi-chevron-right")) {
        const arrow = document.createElement("i");
        arrow.classList.add("bi", "bi-chevron-right");
        item.appendChild(arrow);
      }
    });
    overlay.classList.add(NAV_OPEN_CLASS);
    toggle.classList.add("collapsed"); // visual state if you want
    toggle.setAttribute("aria-expanded", "true");
    overlay.setAttribute("aria-hidden", "false");
    // trap body scroll optionally:
    document.body.style.overflow = "hidden";
  }
  function closeNav() {
    overlay.classList.remove(NAV_OPEN_CLASS);
    toggle.classList.remove("collapsed");
    toggle.setAttribute("aria-expanded", "false");
    overlay.setAttribute("aria-hidden", "true");
    document.body.style.overflow = "";
  }
  //   document.getElementById("closeToggler").addEventListener("click", (e) => {
  //     e.preventDefault();
  //     closeNav();
  //   });

  toggle.addEventListener("click", (e) => {
    e.preventDefault();
    overlay.classList.contains(NAV_OPEN_CLASS) ? closeNav() : openNav();
  });

  // close when clicking any nav link
  document
    .querySelectorAll(".overlay-link")
    .forEach((a) => a.addEventListener("click", () => closeNav()));

  // close on Esc
  document.addEventListener("keydown", (e) => {
    if (e.key === "Escape") closeNav();
  });

  // optional: close when clicking outside inner area
  overlay.addEventListener("click", (e) => {
    if (e.target === overlay) closeNav();
  });
});
