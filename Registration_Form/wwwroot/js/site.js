// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$().ready(function () {
    $("#registrationForm").validate({
        rules: {
            FirstName: "required",
            LastName: "required",
            Email: {
                required: true,
                email: true
            },
            Country: "required"
        },

        messages: {
            FirstName: "Please enter your first name",
            LastName: "Please enter your last name",
            Email: "Please enter a valid email address",
            Country: "Please choose a country"
        }
    });
});
