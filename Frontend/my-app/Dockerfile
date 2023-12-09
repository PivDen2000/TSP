FROM node:14 AS build
WORKDIR /app
COPY package*.json ./
RUN npm install
RUN npm install sass --save-dev
RUN npm install d3 --save-dev
COPY . .
RUN npm run build

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/build .
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
