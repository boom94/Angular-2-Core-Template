"use strict";
var login_component_1 = require("./login/login.component");
exports.adminPublicRoutes = [
    { path: '', component: login_component_1.LoginComponent },
    { path: '**', redirectTo: '' }
];
//# sourceMappingURL=admin.public.routes.js.map