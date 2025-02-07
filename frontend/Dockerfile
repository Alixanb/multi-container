#Frontend
FROM node:18-alpine AS build-stage
WORKDIR /app
RUN npm install -g pnpm
COPY package*.json pnpm-lock.yaml ./
COPY .npmrc ./
RUN pnpm install
COPY . .
RUN pnpm run build

FROM nginx:stable-alpine
COPY --from=build-stage /app/dist /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]