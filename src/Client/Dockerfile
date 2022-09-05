FROM node:18.8.0-alpine3.16 as build-step
WORKDIR /app
COPY package.json ./
RUN npm install
COPY . .
RUN npm run build

FROM nginx:1.23.1-alpine as prod-stage
COPY --from=build-step /app/dist/Client /usr/share/nginx/html