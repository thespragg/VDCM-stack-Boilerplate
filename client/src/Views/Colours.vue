<template>
  <div>
    <div class="container shadow">
      <div class="palette">
        <h3>Muted</h3>
        <div class="colours">
          <div class="colour" style="background-color: #D6A2AD">
            <p>#D6A2AD</p>
          </div>
          <div class="colour" style="background-color: #C3B59F">
            <p>#C3B59F</p>
          </div>
          <div class="colour" style="background-color: #A0AF84">
            <p>#A0AF84</p>
          </div>
          <div class="colour" style="background-color: #668F80">
            <p>#668F80</p>
          </div>
          <div class="colour" style="background-color: #4A6670">
            <p>#4A6670</p>
          </div>
        </div>
      </div>
      <div class="palette">
        <h3>Laid back</h3>
        <div class="colours">
          <div class="colour" style="background-color: #474448">
            <p>#474448</p>
          </div>
          <div class="colour" style="background-color: #2D232E">
            <p>#2D232E</p>
          </div>
          <div class="colour" style="background-color: #E0DDCF;color:black">
            <p>#E0DDCF</p>
          </div>
          <div class="colour" style="background-color: #534B52">
              <p>#534B52</p>
          </div>
          <div class="colour" style="background-color: #F1F0EA; color:black">
              <p>#F1F0EA</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
.container {
  padding: 20px;
  text-align: left;
  background-color: white;
}

.colours {
  display: flex;
  height: 200px;
}

.colour {
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  font-size: 20pt;
  color: white;
}
</style>