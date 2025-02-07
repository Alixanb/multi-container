import { mount } from "@vue/test-utils";
import App from "./App.vue";

describe("App.vue", () => {
  it("renders message", () => {
    const wrapper = mount(App);
    expect(wrapper.find("h1").text()).toBe("Test de Communication");
  });
});
