For bootstrap 4.0.0 integration, refer to the github issue below:
https://github.com/twbs/bootstrap/issues/24078

Currently the project is only configured to use the CSS from bootstrap.

Non-CSS bootstrap features will require the installation of JQuery to function.

To resolve the WARN messages below, install JQuery using the following path and command:

C:\Source\Repos\GpwEditor\App.Web\ClientApp>npm install jquery


-----

C:\Source\Repos\GpwEditor\App.Web\ClientApp>npm update
npm WARN bootstrap@4.0.0 requires a peer of jquery@1.9.1 - 3 but none is installed. You must install peer dependencies yourself.
npm WARN bootstrap@4.0.0 requires a peer of popper.js@^1.12.9 but none is installed. You must install peer dependencies yourself.
npm WARN optional SKIPPING OPTIONAL DEPENDENCY: fsevents@1.1.3 (node_modules\fsevents):
npm WARN notsup SKIPPING OPTIONAL DEPENDENCY: Unsupported platform for fsevents@1.1.3: wanted {"os":"darwin","arch":"any"} (current: {"os":"win32","arch":"x64"})

+ @angular/platform-browser@5.2.5
+ @angular/compiler@5.2.5
+ @angular/compiler-cli@5.2.5
+ @angular/http@5.2.5
+ @angular/language-service@5.2.5
+ @angular/platform-browser-dynamic@5.2.5
+ @angular/common@5.2.5
+ @angular/animations@5.2.5
+ @angular/forms@5.2.5
+ @angular/core@5.2.5
+ @types/node@6.0.101
+ @angular/platform-server@5.2.5
+ @angular/router@5.2.5
updated 13 packages in 25.282s
