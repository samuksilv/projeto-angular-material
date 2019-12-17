### STAGE 1: Build ###
FROM node:12.7-alpine AS build
WORKDIR /usr/src/app
COPY ./portal-angular-material/package.json ./
COPY nginx.conf /etc/nginx/nginx.conf
RUN npm install
COPY ./portal-angular-material .
RUN npm run build-prod


### STAGE 2: Run ###
FROM nginx:1.17.1-alpine

COPY --from=build /usr/src/app/dist/portal-angular-material /usr/share/nginx/html