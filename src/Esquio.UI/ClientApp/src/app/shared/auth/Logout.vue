<template>
<div class="login">{{$t('common.loading')}}</div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import { Inject } from 'inversify-props';
import { IAuthService } from './iauth.service';

@Component
export default class extends Vue {
  public name = 'Logout';

  @Inject() authService: IAuthService;

  public async created(): Promise<void> {
    if (this.authService.user) {
      await this.authService.logout();
      return;
    }

    this.$router.push('/');
  }
}
</script>
