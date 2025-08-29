/** @type {import('tailwindcss').Config} */
module.exports = {
  important: true,
  content: [
    "./Views/**/*.cshtml",   // Razor views
    "./Pages/**/*.cshtml",
    "./wwwroot/js/**/*.js", // Your JS
    "./**/*.html"
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}
