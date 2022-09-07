FROM node:16.13.0-alpine as build
COPY . /app
WORKDIR /app
RUN npm install
RUN npm install @angular/cli
RUN npm run build

FROM nginx:1.17.10-alpine
COPY nginx.conf /etc/nginx/conf.d/default.conf

COPY --from=build app/dist/client /usr/share/nginx/html

EXPOSE 80

# When the container starts, replace the env.js with values from environment variables
CMD ["/bin/sh",  "-c",  "envsubst < /usr/share/nginx/html/assets/env.template.js > /usr/share/nginx/html/assets/env.js && exec nginx -g 'daemon off;'"]
